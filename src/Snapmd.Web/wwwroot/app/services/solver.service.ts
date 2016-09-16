import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import {TransfusionsResult} from '../models/transfusions-result';
import {TaskInput} from '../models/task-input';

@Injectable()
export class SolverService {

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private Url = 'api/solver';  // URL to web api

    constructor(private http: Http) { }

    getDecision(params: TaskInput): Promise<TransfusionsResult> {
        console.log('solving');
        debugger;  
        return this.http
            .post(this.Url, params, { headers: this.headers })
            .toPromise()
            .then(response => response.json() as TransfusionsResult )
            .catch(this.handleError);
    }

    handleError(data: any): any {
        console.log(`error '${data}'`);
    }

}