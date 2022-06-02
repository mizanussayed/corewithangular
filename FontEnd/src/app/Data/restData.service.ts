import { HttpClient } from "@angular/common/http";
import {Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Member } from "../Models/member.model";


@Injectable()
export class RestDataService {
    constructor(private http: HttpClient) {

    }

    getAll<T>(url: string): Observable<T[]> {
        return this.SendRequest<T[]>("GET", url);
    }

    saveEntry(entry: any, url: string): Observable<any> {
        console.log(entry);
        
        return this.SendRequest("POST", url + "/create",entry);
    }

    saveMember(entry: any, url: string): Observable<any> {
        return this.SendRequest("POST", url + `/create?picture=${entry.picture}&cardNumber=${entry.cardNumber}&Name=${entry.name}&RoomNumber=${entry.roomNumber}&department=${entry.department}&phoneNumber=${entry.phoneNumber}&session=${entry.session}&year=${entry.year}&block=${entry.block}&bloodGroup=${entry.bloodGroup}`, entry);
    }

    updateEntry(entry: any, url: string): Observable<any> {
        console.log("dddd");
        return this.http.post(url+"/edit",entry);
    }


    deleteEntry<T>(id: number, url: string): Observable<T> {
        return this.SendRequest("DELETE", url + "/delete/" + id);
    }

    SingleData<T>(id:number, url:string): Observable<any>{
        return this.http.get(url+ `/single/${id}`);
    }


    private SendRequest<T>(verb: string, url: string, body?: T): Observable<T> {
        return this.http.request<T>(verb, url, { body: body });
    }

}