import { Injectable } from '@angular/core';
import { HttpClient } from './httpclient.service';



@Injectable()
export class UserService {
    config: any;
    constructor(private http: HttpClient)
    { }

    // Get All Users
    GetAll() {
        return this.http.get("/auth");
    }
    // Get User By ID
    GetOne(id) {
        return this.http.get("/auth/GetUser/" + id);
    }

    // Add New User
    Add(data) {
        return this.http.post("/user", data);
    }

    // Update Existing User
    Update(data) {
        return this.http.put("/auth/" + data.id, data);
    }

    // Delete User By ID
    Delete(data) {
        console.log("User ID",data);
        return this.http.delete("/auth/" + data);
    }


}