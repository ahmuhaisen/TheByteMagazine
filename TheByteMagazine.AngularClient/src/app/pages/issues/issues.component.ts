import { Component, inject, OnInit, signal } from '@angular/core';

import { Issue } from '../../core/models/issue.model';
import { IssuesService } from '../../core/services/issues.service';
import { IssueCardComponent } from './issue-card/issue-card.component';
import { LoaderComponent } from '../../components/loader/loader.component';
import { convertToIssueShortInfo } from '../../core/models/issueShortInfo.model';
import { PageHeaderComponent } from '../../components/page-header/page-header.component';
import { LatestIssueBanerComponent } from './latest-issue-baner/latest-issue-baner.component';



@Component({
  selector: 'app-issues',
  standalone: true,
  imports: [
    PageHeaderComponent,
    LoaderComponent,
    IssueCardComponent,
    LatestIssueBanerComponent
  ],
  templateUrl: './issues.component.html',
  styleUrl: './issues.component.css'
})
export class IssuesComponent implements OnInit {
  pageTitle = 'All Issues';
  pageDescription = 'The Byte Journal is a student-run tech magazine that explores the latest innovations, trends, and insights in the world of technology. Our mission is to empower young minds with knowledge, creativity, and a passion for shaping the digital future.'

  private issuesService = inject(IssuesService);

  allIssues: Issue[] = [];
  latestIssue!: Issue;

  isFetched = signal(false);

  ngOnInit() {
    this.issuesService.loadAllIssues().subscribe({
      next: (response: any) => {
        const result = response.data.map((item: any) => convertToIssueShortInfo(item));

        this.latestIssue = result[0];

        this.allIssues = result.slice(1);

        this.isFetched.set(true);
      },
      complete: () => this.isFetched.set(true)
    });
  }
}