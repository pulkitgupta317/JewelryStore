import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';
import { AuthRequest, AuthResponse } from 'src/app/models';
import { UserService } from 'src/app/services';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  const authResponse: AuthResponse = {
    AccessToken: "testing",
    ExpireIn: 10,
    UserName: "Test",
    UserRole: "abcde"
  };
  const userService: any = {
    authenticateUser(obj: AuthRequest) {
      return of(authResponse);
    }
  };

  const router = {
    navigate: jasmine.createSpy('navigate')
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule, ReactiveFormsModule],
      declarations: [LoginComponent],
      providers: [
        FormBuilder,
        {
          provide: UserService,
          useValue: userService
        },
        {
          provide: Router,
          useValue: router
        },
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should onSubmit', () => {
    spyOn(userService, 'authenticateUser');
    component.onSubmit();
  });
});
