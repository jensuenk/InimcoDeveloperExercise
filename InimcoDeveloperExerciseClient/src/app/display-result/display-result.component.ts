import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-display-result',
  standalone: true,
  imports: [MatCardModule, CommonModule],
  templateUrl: './display-result.component.html',
  styleUrl: './display-result.component.scss'
})
export class DisplayResultComponent {
  @Input() result: any;
}
