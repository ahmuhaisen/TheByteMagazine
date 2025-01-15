import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, map, throwError } from "rxjs";
import { environment } from "../../../environments/environment";
import { ApiResult } from "../models/api-response.model";
import { Router } from "@angular/router";



@Injectable({ providedIn: 'root' })
export class IssuesService {

  private httpClient = inject(HttpClient);
  private router = inject(Router);


  loadAllIssues() {
    return this.fetchAllIssues(`${environment.apiUrl}/Issues`);
  }

  loadLatestIssue() {
    return this.fetchLatestIssue(`${environment.apiUrl}/Issues/latest`);
  }

  loadTopContributors(count: number) {
    return this.fetchTopContributors(`${environment.apiUrl}/volunteers/top`, count).pipe(
      map(data => {
        let contributions = data as any[];
        return contributions;
      })
    );
  }

  loadHomeIssues() {
    return this.fetchHomeIssues(`${environment.apiUrl}/Issues`);
  }

  loadLatest5IssueCoverImages() {
    return this.fetchLatest5IssueCoverImages(`${environment.apiUrl}/Issues/latest/covers`);
  }

  private fetchAllIssues(url: string) {
    return this.httpClient.get<{ response: ApiResult }>(url)
      .pipe(
        map(resData => {
          return resData;
        }),
        catchError(
          (error) => {
            this.handleServerErorr();
            return throwError(() => new Error(error));
          }
        )
      );
  }

  private fetchLatestIssue(url: string) {
    return this.httpClient.get<ApiResult>(url)
      .pipe(
        map(resData => {
          console.log(resData);
          return resData.data;
        }),
        catchError(
          (error) => {
            this.handleServerErorr();
            return throwError(() => new Error(error));
          }
        )
      );
  }

  private fetchLatest5IssueCoverImages(url: string) {
    return this.httpClient.get<ApiResult>(url)
      .pipe(
        map(resData => {
          return resData.data;
        }),
        catchError(
          (error) => {
            this.handleServerErorr();
            return throwError(() => new Error(error));
          }
        )
      );
  }

  private fetchTopContributors(url: string, count: number) {
    return this.httpClient.get<ApiResult>(url, { params: { number: count } })
      .pipe(
        map(resData => {
          return resData.data;
        }),
        catchError(
          (error) => {
            this.handleServerErorr();
            return throwError(() => new Error(error));
          }
        )
      );
  }

  private fetchHomeIssues(url: string) {
    return this.httpClient.get<{ response: ApiResult }>(url)
      .pipe(
        map(resData => {
          return resData;
        }),
        catchError(
          (error) => {
            this.handleServerErorr();
            return throwError(() => new Error(error));
          }
        )
      );
  }

  private handleServerErorr() {
    this.router.navigate(['server-error']);
  }
}
