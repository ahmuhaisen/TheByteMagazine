import { Component, ElementRef, inject, signal, viewChild } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ContactService } from '../../../core/services/contact.service';
import { Message } from '../../../core/models/message.model';
import { LoaderComponent } from '../../../components/loader/loader.component';


@Component({
  selector: 'app-contact-form',
  standalone: true,
  imports: [ReactiveFormsModule, LoaderComponent],
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.css'
})
export class ContactFormComponent {
  contactForm = this.createContactForm();
  private submitButton = viewChild.required<ElementRef<HTMLButtonElement>>('submitButton');
  private contactService = inject(ContactService);

  isSending = signal(false);

  createContactForm(): FormGroup {
    return new FormGroup({
      name: new FormControl('', {
        validators: [Validators.required, Validators.minLength(5), Validators.maxLength(30)]
      }),
      email: new FormControl('', {
        validators: [Validators.required, Validators.email]
      }),
      message: new FormControl('', {
        validators: [Validators.required, Validators.minLength(5), Validators.maxLength(500)]
      })
    });
  }

  isControlInvalid(controlName: string) {
    return this.contactForm.controls[controlName].invalid &&
      this.contactForm.controls[controlName].dirty &&
      this.contactForm.controls[controlName].touched;
  }


  onSubmit() {
    if (this.isControlInvalid('name') ||
       this.isControlInvalid('email') ||
       this.isControlInvalid('message') ||
       this.contactForm.invalid)  return;

    console.log("Sending...");

    this.disableForm();

    this.isSending.set(true);

    const messageToPost: Message = {
      name: this.contactForm.value["name"],
      email: this.contactForm.value["email"],
      body: this.contactForm.value["message"]
    }

    this.contactService.sendMessage(messageToPost).subscribe({
      error: () => {
        this.reEnableForm();
        this.isSending.set(false);
      },
      next: (response) => {
        this.contactService.showSuccessMessage();
        this.reEnableForm();
        this.isSending.set(false);
      }
    })
  }

  disableForm(){
    this.contactForm.disable();
    this.submitButton().nativeElement.disabled = true;
    this.submitButton().nativeElement.innerHTML = 'Sending...';
  }

  reEnableForm() {
    this.contactForm.enable();
    this.submitButton().nativeElement.disabled = false;
    this.submitButton().nativeElement.innerHTML = 'Send';
    this.contactForm.reset();
  }
}



