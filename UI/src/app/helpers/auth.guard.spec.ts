import { TestBed } from '@angular/core/testing';
import { AuthResponse } from '../models';
import { AuthService } from '../services';

import { AuthGuard } from './auth.guard';

describe('AuthGuard', () => {
  let guard: AuthGuard;
  const authServiceStub: Partial<AuthService> = {
    get userValue(): AuthResponse {
      return {
        AccessToken: 'testing',
        ExpireIn: 12,
        UserName: 'Something',
        UserRole: 'Something'
      };
    }
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: AuthService,
          useValue: authServiceStub
        }
      ]
    });
    guard = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });

  it('should be success on canActivate', () => {
    expect(guard.canActivate(null, null)).toBeTruthy();
  });
});
