import { Component, CUSTOM_ELEMENTS_SCHEMA, inject } from '@angular/core';
import { convertToIssueShortInfo, IssueShortInfo } from '../../../core/models/issueShortInfo.model';
import { RouterLink } from '@angular/router';
import { IssuesService } from '../../../core/services/issues.service';

@Component({
  selector: 'app-issues-slider',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './issues-slider.component.html',
  styleUrl: './issues-slider.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class IssuesSliderComponent {

  issuesService = inject(IssuesService);
  issues: IssueShortInfo[] = [];
  
  ngOnInit() {
    this.issuesService.loadHomeIssues().subscribe({
      next: (response: any) => {
        console.log(response);
        const result = response.data.map((item: any) => convertToIssueShortInfo(item));

        this.issues = result.slice(0, 10);
      }
    });
  }
}
