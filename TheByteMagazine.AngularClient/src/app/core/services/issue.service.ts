import { HttpClient } from "@angular/common/http";
import { ResolveFn, Router } from "@angular/router";
import { inject, Injectable, signal } from "@angular/core";
import { catchError, map, of, tap, throwError } from "rxjs";

import { ApiResult } from "../models/api-response.model";
import { Contribution } from "../models/contribution.model";

import { environment } from "../../../environments/environment";
import { Issue } from "../models/issue.model";


@Injectable({ providedIn: 'root' })
export class IssueService {
    private httpClient = inject(HttpClient);
    private router = inject(Router);

    currentIssue = signal<Issue | undefined>(undefined);
    currentIssueArticles = signal<Article[] | undefined>(undefined);

    loadIssue(id: number) {
        return this.fetchIssueById(`${environment.apiUrl}/Issues`, id).pipe(
            tap({
                next: issue => {
                    this.currentIssue.set(issue as Issue);
                }
            })
        );
    }

    loadIssueTeam(id: number) {
        return this.fetchIssueTeamById(`${environment.apiUrl}/Issues`, id).pipe(
            map(data => {
                let contributions = data as Contribution[];
                return contributions;
            })
        );
    }

    loadIssueArticles(id: number) {
        return this.fetchIssueArticleById(`${environment.apiUrl}/Issues/${id}/articles`).pipe(
            tap({
                next: articles => {
                    this.currentIssueArticles.set(articles as Article[]);
                }
            })
        )
    }

    private fetchIssueById(url: string, id: number) {
        return this.httpClient.get<Issue>(`${url}/${id}`)
            .pipe(
                map(resData => {
                    return resData
                }),
                catchError(
                    (error) => {
                        this.router.navigate(['not-found']);
                        return throwError(() => new Error(error));
                    }
                )
            );
    }

    private fetchIssueTeamById(url: string, id: number) {
        return this.httpClient.get<ApiResult>(`${url}/${id}/team`)
            .pipe(
                map(resData => {
                    return resData.data;
                }),
                catchError(
                    (error) => {
                        this.router.navigate(['not-found']);
                        return throwError(() => new Error(error));
                    }
                )
            );
    }

    private fetchIssueArticleById(url: string) {
        return this.httpClient.get<ApiResult>(`${url}`)
            .pipe(
                map(resData => {
                    console.log(resData);
                    return resData.data;
                }),
                catchError(
                    (error) => {
                        this.router.navigate(['not-found']);
                        return throwError(() => new Error(error));
                    }
                )
            );
    }
}


export const resolveIssue: ResolveFn<Issue | undefined> = (
    activatedRouteSnapshot,
    routerState
) => {
    const issueService = inject(IssueService);
    const router = inject(Router);
    const id = +activatedRouteSnapshot.paramMap.get('issueId')!;

    console.log(id);

    return issueService.loadIssue(id).pipe(
        map((response) => {
            if (response) {
                console.log(response);
                return response;
            } else {
                console.log('Issue Not Found');
                router.navigate(['not-found']);
                return undefined;
            }
        }),
        catchError(() => {
            router.navigate(['not-found']);
            return of(undefined);
        })
    );
};

export interface Article {
    title: string;
    pageNumber: number;
}