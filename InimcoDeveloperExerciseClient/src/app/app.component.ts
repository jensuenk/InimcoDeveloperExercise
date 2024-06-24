import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DisplayResultComponent } from './display-result/display-result.component';
import { UserInputComponent } from './user-input/user-input.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DisplayResultComponent, UserInputComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'InimcoDeveloperExercise';
}
