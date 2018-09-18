export class MenuItem {
    constructor(
        public menuID: number,
        public menuIcon: string,
        public menuSystemName: string,
        public menuSystemUrl: string,
        public useFlag: boolean,
        public childs: MenuItem[],
        public badge: Badge
    ) {

    }
}
export class Badge {
    constructor(
        public variant: string,
        public text: string
    ) {
    }
}
export class AuthenticationResponse {
    constructor(
        public menus: MenuItem[]
    ) {
    }
}
