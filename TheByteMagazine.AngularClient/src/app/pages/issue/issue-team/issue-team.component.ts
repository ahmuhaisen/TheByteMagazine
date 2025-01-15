import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { ContributionCardComponent } from './contribution-card/contribution-card.component';
import { IssueService } from '../../../core/services/issue.service';
import { Contribution } from '../../../core/models/contribution.model';

@Component({
  selector: 'app-issue-details',
  standalone: true,
  imports: [ContributionCardComponent],
  templateUrl: './issue-team.component.html',
  styleUrl: './issue-team.component.css'
})
export class IssueTeamComponent implements OnInit {

  issueService = inject(IssueService);
  
  private team = signal<Contribution[]>([]);

  selectedRole = signal<string>('all');

  availableRoles = computed(() => {
    const allRoles = this.team().map(contribution => contribution.role);
    return allRoles.filter((role, index) => allRoles.indexOf(role) === index);
  });

  issueTeam = computed(() => {
    if (this.selectedRole() === 'all') {
      return this.team().sort((a, b) => a.role.localeCompare(b.role));
    }
    return this.team().filter(c => c.role == this.selectedRole());
  });

  ngOnInit(): void {
    this.issueService.loadIssueTeam(this.issueService.currentIssue()!.id).subscribe({
      error: error => {
        console.log("An Error Occurred while fetching team info!", error);
      },
      next: resData => {
        this.team.set(resData as Contribution[]);
      }
    });
  }


  onRoleChange(event: Event) {
    const value = (event.target as HTMLSelectElement).value;
    this.selectedRole.set(value);
  }
}
