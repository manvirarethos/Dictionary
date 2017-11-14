import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from './httpclient.service';


@Injectable()
export class DictonaryService {

     constructor(private http: HttpClient,private _http:Http)
    { }



      // Get All headings
    GetAll() {
        return this.http.get("/dictonary");
    }
    // Get heading By ID
    GetOne(id) {
        return this.http.get("/dictonary/" + id);
    }

    // Add New heading
    Add(data) {
        return this.http.post("/dictonary", data);
    }

    // Update Existing heading
    Update(data) {
        return this.http.put("/dictonary", data);
    }

    // Delete heading By ID
    Delete(data) {
        console.log("heading ID",data);
        return this.http.delete("/role/" + data);
    }

    // Add New heading
    GetColumnWise(data) {
        return this.http.post("/dictonary/columns", data);
    }

   
    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return JSON.parse("{rstatus:1,msg:'error',data:[]}");
    }



}
