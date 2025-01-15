import { Component, CUSTOM_ELEMENTS_SCHEMA, inject } from '@angular/core';

import { IssuesService } from '../../../core/services/issues.service';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class HeroComponent {

  coverImagesUrls: string[] = [];
  issuesService = inject(IssuesService);
  constructor() {
    this.issuesService.loadLatest5IssueCoverImages().subscribe({
      next: (response) => {
        this.coverImagesUrls = response.map((item: any) => environment.staticFilesUrl + '/' + item);
      }
    })
  }
}
