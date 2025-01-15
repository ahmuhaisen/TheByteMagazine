import { Component, input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Issue } from '../../../core/models/issue.model';



@Component({
  selector: 'app-issue-card',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './issue-card.component.html',
  styleUrl: './issue-card.component.css'
})
export class IssueCardComponent {
  issue = input.required<Issue>();
}
