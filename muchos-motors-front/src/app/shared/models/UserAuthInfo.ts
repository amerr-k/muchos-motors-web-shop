export interface UserAuthInfo {
  authenticationToken: AuthenticationToken;
  isLoggedIn: boolean;
}

export interface AuthenticationToken {
  authenticationTokenId: number;
  value: string;
  userAccountId: number;
  userAccount: UserAccount;
  createdDate: string;
  ipAddress: string;
}

export interface UserAccount {
  userAccountId: number;
  firstName: string;
  lastName: string;
  address: string;
  email: string;
  cityId: string;
  phone: string;
  username: string;
  password: string;
  userPicture: string;
  isCustomer: boolean;
  isEmployee: boolean;
  isAdmin: boolean;
}
