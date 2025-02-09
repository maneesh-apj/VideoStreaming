import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-video-player',
  template: `
    <video controls width="640" height="360">
      <source [src]="videoUrl" type="video/mp4">
      Your browser does not support the video tag.
    </video>
  `,
})
export class VideoPlayerComponent {
  videoUrl: string;

  constructor(private http: HttpClient) {
    this.videoUrl = 'https://localhost:44359/api/proxy/stream/Movie1.mp4';
  }
}
