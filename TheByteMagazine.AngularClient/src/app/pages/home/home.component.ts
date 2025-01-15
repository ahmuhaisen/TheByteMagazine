import { Component } from '@angular/core';
import { HeroComponent } from "./hero/hero.component";

import { LatestIssueComponent } from "./latest-issue/latest-issue.component";
import { IssuesSliderComponent } from "./issues-slider/issues-slider.component";
import { TopContributorsComponent } from "./top-contributors/top-contributors.component";
import { EditorialOfficeComponent } from "./editorial-office/editorial-office.component";
import { SectionLoaderComponent } from "../../components/section-loader/section-loader.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeroComponent, LatestIssueComponent, TopContributorsComponent, IssuesSliderComponent, EditorialOfficeComponent, SectionLoaderComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
}
