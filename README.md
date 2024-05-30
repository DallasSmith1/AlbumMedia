<h1>Album Media</h1>
<p>I developed Almbum Media as a personal project to visualize and share family photos and movies stored on an external hard drive. The platform allows friends and family connected to my home WiFi to create accounts, watch movies, and navigate the library akin to an online streaming service. Users can upload photos, which are tagged using Microsoft Azure's Computer Vision model for easier search. Additionally, users can share and download uploaded photos within the app.</p>
<p>I used WPF and the .NET framework to create this applicationwith originally using a local MariaDB database.</p>
<h3>Features</h3>
<p>The app allows movie streaming of all movies I have stored on the 5TB hard drive. (All movies were pre-owned on DVD and converted to mp4 for this project):</p>
<img src="https://i.imgur.com/kPy4vqZ.png"/>
<p>Due to the application being built in the .NET framework, there weren't many options for video players, so I had to create my own:</p>
<img src="https://i.imgur.com/FGm0FbT.png"/>
<p>The photo storage section will store as many photos as the drive can handle (5TB) and every single photo uploaded will have tags stamped to it to identify it via search results:</p>
<table>
  <tr>
    <td><img src="https://i.imgur.com/uc1my1v.png" width="500" height="325"/></td>
    <td><img src="https://i.imgur.com/6k1aEIi.png" width="500" height="325"/></td>
  </tr>
</table>
<hr/>
<h3>Summary</h3>
<p>I enjoyed creating this app and gained new skills, including Computer Vision, working with APIs, and setting up automated no-reply emails. The project was a valuable introduction to desktop app development, revealing the limitations of WPF and sparking my curiosity to explore alternative frameworks. This led me to discover Tauri, which I adopted for developing a transit app after completing this project.
