import { ResolveFn, Route } from "@angular/router";
import { inject } from "@angular/core";
import { IssueService } from "../../core/services/issue.service";


export const titleResolver: ResolveFn<string> = (route, state) => {
    let issueService = inject(IssueService);
    return `${issueService.currentIssue()!.title}`;
};

export const routes: Route[] = [
    {
        path: '',
        redirectTo: 'overview',
        pathMatch: 'prefix'
    },
    {
        path: "overview",
        loadComponent: () => import('./issue-overview/issue-overview.component').then(f => f.IssueOverviewComponent),
        title: titleResolver,
        data: { breadcrumb: 'Overview' }
    },
    {
        path: "team",
        loadComponent: () => import('./issue-team/issue-team.component').then(f => f.IssueTeamComponent),
        title: titleResolver,
        data: { breadcrumb: 'Team' },
    },
    {
        path: "read",
        loadComponent: () => import('./issue-read/issue-read.component').then(f => f.IssueReadComponent),
        title: titleResolver,
        data: { breadcrumb: 'Read' }
    }
]