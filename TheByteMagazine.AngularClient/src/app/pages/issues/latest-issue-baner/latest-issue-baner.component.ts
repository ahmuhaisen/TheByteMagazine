import { Component, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';
import { Issue } from '../../../core/models/issue.model';

@Component({
  selector: 'app-latest-issue-baner',
  standalone: true,
  imports: [RouterLink, DatePipe],
  templateUrl: './latest-issue-baner.component.html',
  styleUrl: './latest-issue-baner.component.css'
})
export class LatestIssueBanerComponent {
  issue = input.required<Issue>()
}
