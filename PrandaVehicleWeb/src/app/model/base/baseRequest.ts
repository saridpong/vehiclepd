export class BaseRequest {
    all: boolean;
    pageNumber: number;
    constructor() {
        this.all = false;
        this.pageNumber = 1;
    }
}
