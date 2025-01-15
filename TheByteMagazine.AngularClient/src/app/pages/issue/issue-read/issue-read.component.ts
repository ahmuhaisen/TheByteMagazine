import { Component, OnInit, signal } from '@angular/core';
import { LoaderComponent } from "../../../components/loader/loader.component";

@Component({
  selector: 'app-issue-read',
  standalone: true,
  imports: [LoaderComponent],
  templateUrl: './issue-read.component.html',
  styleUrl: './issue-read.component.css'
})
export class IssueReadComponent implements OnInit{

  isLoading = signal(true);

  ngOnInit(): void {
    setTimeout(() => {
      this.isLoading.set(false);
    }, 4000)
  }
}
