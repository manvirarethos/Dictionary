import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from './httpclient.service';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import { Menu } from '../_models/_index.model';


@Injectable()
export class LanguageService {
    private _headingBaseUrl = 'assets/menu.json';  
     constructor(private http: HttpClient)
    { }


    
    

      // Get All headings
    GetAll() {
        return this.http.get("/language");
    }
    // Get heading By ID
    GetOne(id) {
        return this.http.get("/language/" + id);
    }

    // Add New heading
    Add(data) {
        return this.http.post("/language", data);
    }

    // Update Existing heading
    Update(data) {
        return this.http.put("/language/" , data);
    }

    // Delete heading By ID
    Delete(data) {
        console.log("heading ID",data);
        return this.http.delete("/language/" + data);
    }

   

    // Add New heading
    GetDBMenu() {
        return this.http.get("/language");
    }
    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return JSON.parse("{status:1,msg:'error',data:[]}");
    }



}
