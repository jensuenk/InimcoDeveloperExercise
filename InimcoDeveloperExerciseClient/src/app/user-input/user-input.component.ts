
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../user.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-input',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatFormFieldModule, ReactiveFormsModule],
  templateUrl: './user-input.component.html',
  styleUrl: './user-input.component.scss'
})
export class UserInputComponent implements OnInit {
  userForm: FormGroup;

  constructor(private fb: FormBuilder, private userService: UserService) {
    this.userForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      lastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      socialSkills: this.fb.array([]),
      socialAccounts: this.fb.array([])
    });
  }

  ngOnInit(): void {}

  get socialSkills(): FormArray {
    return this.userForm.get('socialSkills') as FormArray;
  }

  get socialAccounts(): FormArray {
    return this.userForm.get('socialAccounts') as FormArray;
  }

  addSocialSkill() {
    this.socialSkills.push(this.fb.control(''));
  }

  addSocialAccount() {
    this.socialAccounts.push(this.fb.group({
      type: ['', Validators.required],
      address: ['', Validators.required]
    }));
  }

  onSubmit() {
    if (this.userForm.valid) {
      this.userService.submitUserData(this.userForm.value).subscribe(response => {
        // Handle response
      });
    } else {
      // Handle form errors
    }
  }
}