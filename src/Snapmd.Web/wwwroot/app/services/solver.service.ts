import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import {TransfusionsResult} from '../models/transfusionsResult';

@Injectable()
export class SolverService {

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private heroesUrl = 'app/heroes';  // URL to web api

    constructor(private http: Http) { }

    getDecision(jar1: number, jar2: number, target: number): Promise<TransfusionsResult> {

        console.log('solving');

        return null;
    }
}