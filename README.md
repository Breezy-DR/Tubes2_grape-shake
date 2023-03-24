# Tubes2_grape-shake

## Deskripsi Singkat
Program ini merupakan simulasi game Maze Treasure Hunt dalam bentuk GUI.

## Requirement
- .NET 7.0.202
## Langkah meng-compile
- Change Directory ke `./src`
- ketik `dotnet run` pada terminal
## Cara menggunakan program
- Masukkan nama file yang ada pada `./test` kemudian tekan button 'Create Map'
- Pilih salah satu tipe pencarian (BFS/DFS)
- Tentukan apakah ingin mengimplementasikan TSP dengan menekan check box 'TSP'
- Tekan button 'Search'
- Jika ingin melakukan visualisasi proses pencarian solusi, tekan button 'Simulate Search' setelah proses Search selesai
## Keterangan tambahan
- Prioritas gerakan adalah down > up > right > left
- Terdapat berbagai macam warna pada grid: Hijau menandai jalur solusi, kuning menandai grid yang sudah diperiksa (hanya ada jika ditekan tombol simulate search), biru menandai grid yang sedang diperiksa (hanya ada jika ditekan tombol simulate search). Warna akan menjadi lebih tua jika grid semakin sering dikunjungi.
## Author
- Muhammad Equllibrie Fajria / 13521047
- Muhammad Farrel Danendra Rachim / 13521048
- Tobias Natalio Sianipar / 13521090
