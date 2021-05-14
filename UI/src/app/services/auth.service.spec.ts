import { TestBed } from '@angular/core/testing';
import { AuthResponse } from '../models';

import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get userValue', () => {
    const val: AuthResponse = {
      AccessToken: 'testing',
      ExpireIn: 12,
      UserName: 'Something',
      UserRole: 'Something'
    };
    service.userValue = val;
    expect(service.userValue).toEqual(val);
  });
});
