import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { Observable, of } from 'rxjs';
import { AuthRequest, AuthResponse } from 'src/app/models';
import { UserService } from 'src/app/services';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  const userServiceStub: any = {
    authenticateUser(obj: any): Observable<AuthResponse> {
      return of({
        AccessToken: "testing",
        ExpireIn: 10,
        UserName: "Test",
        UserRole: "abcde"
      });
    }
  };

  const router = {
    navigate: jasmine.createSpy('navigate')
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginComponent],
      providers: [
        FormBuilder,
        {
          provide: UserService,
          useValue: userServiceStub
        },
        {
          provide: Router,
          useValue: router
        },
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should return data', () => {
    const data = component.f;
    expect(data).toBeTruthy();
  });


  it('should onSubmit', () => {
    component.loginForm.setValue({
      UserName: "Mathew",
      Password: "Temppass@1234"
    });
    component.onSubmit();
  });
});
