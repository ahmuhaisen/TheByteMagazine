import { Routes } from '@angular/router';

import { resolveIssue } from './core/services/issue.service';
import { HomeComponent } from './pages/home/home.component';


export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        data: { breadcrumb: 'Home' },
        title: 'Home',
    },
    {
        path: 'issues',
        loadComponent: () => import('./pages/issues/issues.component').then(f => f.IssuesComponent),
        title: 'All Issues',
        data: { breadcrumb: 'All Issues' },
    },
    {
        path: "issue/:issueId",
        loadComponent: () => import('./pages/issue/issue.component').then(f => f.IssueComponent),
        resolve: { issue: resolveIssue },
        data: { breadcrumb: { alias: 'IssueBreadcrumb' } },
        loadChildren: () => import('./pages/issue/issue.routes').then(m => m.routes),
    },
    {
        path: 'contact',
        loadComponent: () => import('./pages/contact/contact.component').then(f => f.ContactComponent),
        data: { breadcrumb: 'Contact Us' },
        title: 'Contact'
    },
    {
      path: 'server-error',
      loadComponent: () => import('./pages/server-error/server-error.component').then(f => f.ServerErrorComponent),
      title: 'Unknown Error'
    },
    {
        path: '**',
        loadComponent: () => import('./pages/not-found/not-found.component').then(f => f.NotFoundComponent),
        title: 'Page Not Found'
    }
];

