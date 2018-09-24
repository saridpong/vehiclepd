import { Injectable } from '@angular/core';

@Injectable()
export class Globals {
    authen: AuthenData;
    // public BaseApiUrl: string = 'http://localhost/PrandaVehicleApi/';
    public BaseApiUrl: string = 'http://localhost/carapi/';

    public setCookie(key: string, value: any): any {
        window.localStorage.setItem(key, JSON.stringify(value))
    }

    public getCookie(key: string): any {
        return JSON.parse(window.localStorage.getItem(key));
    }

}

export interface AuthenData {
    access_token: string;
    token_type: string;
    expires_in: string;
    refresh_token: string;
    userName: string;
    fullName: string;
    companyName: string;
    role: string;
}
