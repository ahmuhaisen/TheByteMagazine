import { Component, inject } from '@angular/core';
import { DatePipe } from '@angular/common';
import { IssueService } from '../../../../core/services/issue.service';

@Component({
  selector: 'app-issue-summary',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './issue-summary.component.html',
  styleUrl: './issue-summary.component.css'
})
export class IssueSummaryComponent {
  issueService = inject(IssueService);
}
