import { Component, OnDestroy } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
  FormsModule,
  FormArray,
} from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { UserService } from '../../providers/services/user.service';
import {
  UserProfile,
  UserProfileResponse,
} from '../../providers/models/user.model';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { DisplayResultComponent } from '../display-result/display-result.component';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { Subject, takeUntil } from 'rxjs';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-user-input',
  standalone: true,
  imports: [
    CommonModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    DisplayResultComponent,
    MatSnackBarModule,
    MatSelectModule,
    MatIconModule,
  ],
  templateUrl: './user-input.component.html',
  styleUrls: ['./user-input.component.scss'],
})
export class UserInputComponent implements OnDestroy {
  userProfileForm: FormGroup;
  response: UserProfileResponse | null = null;
  unsubscribe = new Subject<void>();
  accountTypes = ['Facebook', 'Twitter', 'LinkedIn', 'Instagram'];

  constructor(
    private fb: FormBuilder,
    private userProfileService: UserService,
    private snackBar: MatSnackBar
  ) {
    this.userProfileForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      socialSkills: this.fb.array([]),
      socialAccounts: this.fb.array([]),
    });
  }

  get socialSkills(): FormArray {
    return this.userProfileForm.get('socialSkills') as FormArray;
  }

  get socialAccounts(): FormArray {
    return this.userProfileForm.get('socialAccounts') as FormArray;
  }

  addSocialSkill(): void {
    this.socialSkills.push(this.fb.control('', Validators.required));
  }

  removeSocialSkill(index: number): void {
    this.socialSkills.removeAt(index);
  }

  addSocialAccount(): void {
    this.socialAccounts.push(
      this.fb.group({
        type: ['', Validators.required],
        address: ['', Validators.required],
      })
    );
  }

  removeSocialAccount(index: number): void {
    this.socialAccounts.removeAt(index);
  }

  onSubmit() {
    const userProfile: UserProfile = this.userProfileForm.value;

    this.userProfileService.submitUserProfile(userProfile).pipe(takeUntil(this.unsubscribe)).subscribe({
      next: (response: UserProfileResponse) => {
        this.response = response;
        this.snackBar.open('User profile submitted successfully', 'Close', {
          duration: 3000,
        });
      },
      error: (error: any) => {
        console.error('Error submitting user profile', error);
        this.snackBar.open(`Error: ${error}`, 'Close', {
          duration: 5000,
        });
      },
    });
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
