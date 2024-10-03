using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WMPLib;

namespace Quiz_v0._2.Models
{
    namespace Quiz_v0._2.Models
    {
        namespace Quiz_v0._2.Models
        {
            public class QuizMusicPlayer
            {
                private Random random = new Random();

                // Основний шлях до музичних папок
                private string musicBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Source\default\Song");

                // Шляхи до поточної групи (за замовчуванням використовуємо кореневу директорію)
                private string currentGroupPath;

                // Підкатегорії музики
                private string answerMusicPath;
                private string menuMusicPath;
                private string loseMusicPath;
                private string winMusicPath;
                private string thinkMusicPath;
                private string letsMusicPath;

                private WindowsMediaPlayer player;
                private bool isMusicPlaying;

                public QuizMusicPlayer()
                {
                    player = new WindowsMediaPlayer();
                    player.PlayStateChange += Player_PlayStateChange;
                    SetDefaultMusicPaths(); // Встановлюємо стандартні шляхи при ініціалізації
                }

                // Метод для встановлення стандартних шляхів
                private void SetDefaultMusicPaths()
                {
                    answerMusicPath = Path.Combine(musicBasePath, "answer");
                    menuMusicPath = Path.Combine(musicBasePath, "menu", "menu_main.mp3");
                    loseMusicPath = Path.Combine(musicBasePath, "lose");
                    winMusicPath = Path.Combine(musicBasePath, "win");
                    thinkMusicPath = Path.Combine(musicBasePath, "think");
                    letsMusicPath = Path.Combine(musicBasePath, "lets");
                }

                // Метод для встановлення шляхів для вибраної групи музики
                public void SetMusicGroup(string groupName)
                {
                    currentGroupPath = Path.Combine(musicBasePath, groupName);

                    // Якщо папка існує, змінюємо шляхи
                    if (Directory.Exists(currentGroupPath))
                    {
                        answerMusicPath = Path.Combine(currentGroupPath, "answer");
                        menuMusicPath = Path.Combine(currentGroupPath, "menu", "menu_main.mp3");
                        loseMusicPath = Path.Combine(currentGroupPath, "lose");
                        winMusicPath = Path.Combine(currentGroupPath, "win");
                        thinkMusicPath = Path.Combine(currentGroupPath, "think");
                        letsMusicPath = Path.Combine(currentGroupPath, "lets");
                    }
                    else
                    {
                        MessageBox.Show($"Група не знайдена: {groupName}. Використовуються стандартні шляхи.");
                        SetDefaultMusicPaths();
                    }
                }

                // Обробник події зміни стану відтворення
                private void Player_PlayStateChange(int NewState)
                {
                    if (NewState == 8)
                    {
                        isMusicPlaying = false;
                    }
                }

                // Метод для вибору випадкового треку з категорії
                private string GetRandomTrackFromFolder(string folderPath)
                {
                    if (Directory.Exists(folderPath))
                    {
                        try
                        {
                            var tracks = Directory.GetFiles(folderPath, "*.mp3");
                            if (tracks.Length > 0)
                            {
                                int randomTrackIndex = random.Next(tracks.Length);
                                return tracks[randomTrackIndex];
                            }
                            else
                            {
                                MessageBox.Show($"Немає треків у папці: {folderPath}");
                                return null;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка завантаження треків: {ex.Message}");
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Папка не існує: {folderPath}");
                        return null;
                    }
                }

                // Метод для відтворення музики
                private async Task PlayMusic(string trackPath, bool waitForCompletion)
                {
                    if (!string.IsNullOrEmpty(trackPath))
                    {
                        if (File.Exists(trackPath))
                        {
                            player.URL = trackPath;
                            player.controls.play();
                            MessageBox.Show($"Відтворюється трек: {trackPath}");

                            if (waitForCompletion)
                            {
                                await WaitForMusicToEnd();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Трек не знайдено: {trackPath}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Шлях до треку порожній.");
                    }
                }

                // Відтворення випадкового треку для відповіді на питання
                public async Task PlayAnswerMusic()
                {
                    string track = GetRandomTrackFromFolder(answerMusicPath);
                    await PlayMusic(track, true);
                }

                // Відтворення треку для меню
                public void PlayMenuMusic()
                {
                    PlayMusic(menuMusicPath, false);
                }

                // Відтворення випадкового треку для програшу
                public async Task PlayLoseMusic()
                {
                    string track = GetRandomTrackFromFolder(loseMusicPath);
                    await PlayMusic(track, true);
                }

                // Відтворення випадкового треку для виграшу
                public async Task PlayWinMusic()
                {
                    string track = GetRandomTrackFromFolder(winMusicPath);
                    await PlayMusic(track, true);
                }

                // Відтворення випадкового треку для роздумів
                public async Task PlayThinkMusic()
                {
                    string track = GetRandomTrackFromFolder(thinkMusicPath);
                    await PlayMusic(track, true);
                }

                // Відтворення випадкового треку для вибору питання
                public async Task PlayLetsMusic()
                {
                    string track = GetRandomTrackFromFolder(letsMusicPath);
                    await PlayMusic(track, true);
                }

                // Метод для очікування завершення музики
                private async Task WaitForMusicToEnd()
                {
                    isMusicPlaying = true;
                    while (isMusicPlaying)
                    {
                        await Task.Delay(500);
                    }
                }

                // Зупинка поточної музики
                public void StopMusic()
                {
                    player.controls.stop();
                }

                // Метод для отримання тривалості музичного треку
                public double GetTrackDuration()
                {
                    return player.currentMedia?.duration ?? 0;
                }
            }
        }
    }

}
