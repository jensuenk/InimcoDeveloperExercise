
import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { UserProfileResponse } from '../../providers/models/user.model';

@Component({
  selector: 'app-display-result',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './display-result.component.html',
  styleUrl: './display-result.component.scss'
})
export class DisplayResultComponent {
  @Input() response: UserProfileResponse | null = null;
}
