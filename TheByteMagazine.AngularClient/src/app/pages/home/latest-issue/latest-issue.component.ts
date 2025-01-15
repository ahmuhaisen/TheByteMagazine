import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { map } from 'rxjs';
import { OrdinalPipe } from '../../../core/pipes/ordinal.pipe';
import { environment } from '../../../../environments/environment';
import { IssuesService } from '../../../core/services/issues.service';
import { Issue } from '../../../core/models/issue.model';
import { SectionLoaderComponent } from "../../../components/section-loader/section-loader.component";

@Component({
  selector: 'app-latest-issue',
  standalone: true,
  imports: [RouterLink, OrdinalPipe, SectionLoaderComponent],
  templateUrl: './latest-issue.component.html',
  styleUrl: './latest-issue.component.css'
})
export class LatestIssueComponent implements OnInit {
  issuesService = inject(IssuesService);

  latestIssue = signal<Issue | undefined>(undefined);
  isLoading = false;

  ngOnInit(): void {
    this.isLoading = true;
    this.issuesService.loadLatestIssue().pipe(
      map((response) => {
        let issue = response as Issue;
        return {
          ...issue,
          coverImageUrl: environment.staticFilesUrl + '/' + issue.coverImageUrl,
        }
      })
    )
    .subscribe({
      next: (data) => {
        this.latestIssue.set(data);
        this.isLoading = false;
      }
    });
  }
}
