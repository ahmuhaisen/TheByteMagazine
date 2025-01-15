import { Component, inject, input, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { PageHeaderComponent } from '../../components/page-header/page-header.component';
import { Issue } from '../../core/models/issue.model';

@Component({
  selector: 'app-issue',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, PageHeaderComponent],
  templateUrl: './issue.component.html',
  styleUrl: './issue.component.css'
})
export class IssueComponent implements OnInit{
  issueId = input.required<number>();

  currentIssue = signal<Issue | undefined>(undefined);

  activatedRoute = inject(ActivatedRoute);
  breadcrumbService = inject(BreadcrumbService);

  ngOnInit(): void {
    let issue = this.activatedRoute.snapshot.data['issue'];
    this.currentIssue.set(issue);

    this.breadcrumbService.set('@IssueBreadcrumb', issue.title);
  }
}
