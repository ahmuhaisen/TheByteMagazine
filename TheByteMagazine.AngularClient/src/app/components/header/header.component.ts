import { NgClass } from '@angular/common';
import {ChangeDetectionStrategy, Component} from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  isMenuOpen = false;

  headerItems: headerItem[] = [
    {
      text: "Home",
      link: "",
    },
    {
      text: "All Issues",
      link: "issues",
    },
    {
      text: "Contact",
      link: "contact",
    }
  ];

}

interface headerItem {
  text: string;
  link: string;
}
