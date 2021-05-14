import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { AuthService } from '.';
import { AuthResponse } from '../models';

import { UserService } from './user.service';

describe('UserService', () => {
  let service: UserService;

  const authServiceStub = {
    set userValue(value: any) {

    }
  }

  const httpClientServiceStub = {
    post(url: string, data: any): Observable<AuthResponse> {
      return of({
        AccessToken: 'testing',
        ExpireIn: 12,
        UserName: 'Something',
        UserRole: 'Something'
      });
    }
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: HttpClient,
          useValue: httpClientServiceStub
        },
        {
          provide: AuthService,
          useValue: authServiceStub
        }
      ]
    });
    service = TestBed.inject(UserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be true for authenticate user', () => {
    let result: AuthResponse;
    service.authenticateUser({
      Password: 'Mathew',
      UserName: 'Tempass@1234'
    }).subscribe(x => {
      result = x;
    });
    expect(result).toBeTruthy();
  });
});
