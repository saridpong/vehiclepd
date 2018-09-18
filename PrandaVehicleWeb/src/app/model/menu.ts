export class Menu {
    constructor(
        public menuID: number,
        public menuIcon: string,
        public menuName: string,
        public menuUrl: string,
        public menuHierarchy: number,
        public useFlag: boolean
    ) { }
}
