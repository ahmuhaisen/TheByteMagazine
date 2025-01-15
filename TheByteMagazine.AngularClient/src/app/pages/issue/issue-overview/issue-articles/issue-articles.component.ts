import { Component, input } from '@angular/core';

import { Article } from '../../../../core/services/issue.service';

@Component({
  selector: 'app-issue-articles',
  standalone: true,
  imports: [],
  templateUrl: './issue-articles.component.html',
  styleUrl: './issue-articles.component.css'
})
export class IssueArticlesComponent {
  articles = input.required<Article[] | undefined>()
}
