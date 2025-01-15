import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { PageHeaderComponent } from '../../components/page-header/page-header.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [
    RouterLink,
    ContactFormComponent,
    PageHeaderComponent
  ],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ContactComponent {
  pageTitle = "Contact Us";
  pageDescription = "Reach out to us with any questions or concerns. We'll get back to you as soon as possible.";
}
