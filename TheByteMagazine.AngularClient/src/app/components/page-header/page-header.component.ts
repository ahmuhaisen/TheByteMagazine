import { Component, input } from '@angular/core';
import { BreadcrumbComponent } from 'xng-breadcrumb';


@Component({
  selector: 'app-page-header',
  standalone: true,
  imports: [
    BreadcrumbComponent
  ],
  templateUrl: './page-header.component.html',
  styleUrl: './page-header.component.css'
})
export class PageHeaderComponent {
  title = input.required<string>();
  description = input<string>();
}
