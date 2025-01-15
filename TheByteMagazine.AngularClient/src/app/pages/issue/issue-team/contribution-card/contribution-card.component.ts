import { Component, input } from '@angular/core';
import { Contribution } from '../../../../core/models/contribution.model';

@Component({
  selector: 'app-contribution-card',
  standalone: true,
  imports: [],
  templateUrl: './contribution-card.component.html',
  styleUrl: './contribution-card.component.css'
})
export class ContributionCardComponent {
  contribution = input.required<Contribution>();
}
