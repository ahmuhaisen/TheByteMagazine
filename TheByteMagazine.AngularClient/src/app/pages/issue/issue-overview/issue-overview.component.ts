import { Component, inject,  signal } from '@angular/core';

import { Article, IssueService } from '../../../core/services/issue.service';
import { IssueSummaryComponent } from "./issue-summary/issue-summary.component";
import { IssueArticlesComponent } from "./issue-articles/issue-articles.component";
import { Issue } from '../../../core/models/issue.model';

@Component({
  selector: 'app-issue-overview',
  standalone: true,
  imports: [IssueSummaryComponent, IssueArticlesComponent],
  templateUrl: './issue-overview.component.html',
  styleUrl: './issue-overview.component.css'
})
export class IssueOverviewComponent {

  issueService = inject(IssueService);
  issue = signal<Issue | undefined>(undefined);
  issueArticles = signal<Article[] | undefined>([]);

  ngOnInit() {
    this.issue = this.issueService.currentIssue;

    this.issueService.loadIssueArticles(this.issueService.currentIssue()!.id).subscribe({
      next: resData => {
        this.issueArticles.set(resData as Article[]);
      }
    });

  }
}
