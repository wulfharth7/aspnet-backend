import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    title = 'SignalRClient';
    private usersHubConnectionBuilder!: HubConnection;
    private postsHubConnectionBuilder!: HubConnection;
    offers: any[] = [];
    posts: any[] = [];
    constructor() {}
    ngOnInit(): void {
        this.usersHubConnectionBuilder = new HubConnectionBuilder().withUrl('https://localhost:7260/users').configureLogging(LogLevel.Information).build();
        this.postsHubConnectionBuilder = new HubConnectionBuilder().withUrl('https://localhost:7260/post').configureLogging(LogLevel.Information).build();
        this.usersHubConnectionBuilder.start().then(() => console.log('Connection started.......!')).catch(err => console.log('Error while connect with server'));
        this.postsHubConnectionBuilder.start().then(() => console.log('Connection started.......!')).catch(err => console.log('Error while connect with server'));
        this.usersHubConnectionBuilder.on('ShowAllUserswithSignalR', (result: any) => {
            this.offers = [];
            this.offers.push(JSON.stringify(result));
        });
        this.postsHubConnectionBuilder.on('showRelatedPosts', (result: any) => {
            this.posts = [];
            this.posts.push(JSON.stringify(result));
        });
    }
}