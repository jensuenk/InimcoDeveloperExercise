// user-input.component.spec.ts

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { UserInputComponent } from './user-input.component';
import { UserService } from '../../providers/services/user.service';

describe('UserInputComponent', () => {
  let component: UserInputComponent;
  let fixture: ComponentFixture<UserInputComponent>;
  let snackBarOpenSpy: jasmine.Spy;

  beforeEach(waitForAsync(() => {
    const userServiceMock = jasmine.createSpyObj('UserService', ['submitUserProfile']);

    TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        FormsModule,
        MatCardModule,
        MatInputModule,
        MatSelectModule,
        MatIconModule,
        MatButtonModule,
        MatSnackBarModule
      ],
      providers: [
        { provide: UserService, useValue: userServiceMock },
        MatSnackBar
      ]
    }).compileComponents();

    snackBarOpenSpy = spyOn(TestBed.inject(MatSnackBar), 'open');

    fixture = TestBed.createComponent(UserInputComponent);
    component = fixture.componentInstance;
  }));

  afterEach(() => {
    fixture.destroy();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize form with empty values', () => {
    expect(component.userProfileForm.value).toEqual({
      firstName: '',
      lastName: '',
      socialSkills: [],
      socialAccounts: []
    });
  });

  it('should add and remove social skills', () => {
    component.addSocialSkill();
    expect(component.socialSkills.length).toEqual(1);

    component.removeSocialSkill(0);
    expect(component.socialSkills.length).toEqual(0);
  });

  it('should add and remove social accounts', () => {
    component.addSocialAccount();
    expect(component.socialAccounts.length).toEqual(1);

    component.removeSocialAccount(0);
    expect(component.socialAccounts.length).toEqual(0);
  });

});

