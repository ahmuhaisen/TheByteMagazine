import { Component, CUSTOM_ELEMENTS_SCHEMA, inject, signal } from '@angular/core';
import { Contribution } from '../../../core/models/contribution.model';
import { IssuesService } from '../../../core/services/issues.service';



@Component({
  selector: 'app-top-contributors',
  standalone: true,
  imports: [],
  templateUrl: './top-contributors.component.html',
  styleUrl: './top-contributors.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class TopContributorsComponent {
  issuesService = inject(IssuesService);

  topContributors = signal<Contribution[]>([]);

  ngOnInit(): void {
    this.issuesService.loadTopContributors(6).subscribe({
      error: error => {
        console.log("An Error Occurred while fetching top contributors!", error);
      },
      next: resData => 
        this.topContributors.set(resData)
    });
  }
}
