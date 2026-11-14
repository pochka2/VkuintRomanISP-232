# Git notes

## Task 15 — Basic git

Локальный учебный пример с веткой main. Основная история GitHub не переписывалась.

### Commands

```bash
git init -b main
git add README.md
git commit -m "chore: prepare git practice"
git switch -c feature/git-basics
# Изменена строка в README.md
git add README.md
git commit -m "feat: task 15 - edit feature"
git switch main
# Та же строка изменена другим текстом
git add README.md
git commit -m "feat: task 15 - edit main"
git merge --no-ff feature/git-basics
# Конфликт вручную исправлен, маркеры удалены
git add README.md
git commit -m "feat: task 15 - resolve merge conflict"
git log --graph --oneline --all
```

### Output (merge)

```text
Auto-merging README.md
CONFLICT (content): Merge conflict in README.md
Automatic merge failed; fix conflicts and then commit the result.
```

### Output (git log --graph --oneline --all)

```text
*   6b4526e feat: task 15 - resolve merge conflict
|\
| * 487f52e feat: task 15 - edit feature
* | 43013dc feat: task 15 - edit main
|/
* d905a28 chore: prepare git practice
```

### What I learned

Если две ветки изменили одну строку, Git требует исправить конфликт перед завершением merge.

## Task 35 — Branches and rebase

### Commands

```bash
git switch -c level-2
# По одному коммиту для заданий 16–34
git add .gitignore .editorconfig
git commit -m "chore: add gitignore and editorconfig"
git switch -c feature/task-35
# Два коммита с заметками
git switch main
git merge --no-ff feature/task-35
git switch -c feature/rebase-demo
# Сделаны три коммита, затем:
git rebase -i HEAD~3
# Второй и третий pick заменены на squash
git log --oneline
```

### PR link

Уровень 1: https://github.com/pochka2/VkuintRomanISP-232/pull/1

Уровень 2: https://github.com/pochka2/VkuintRomanISP-232/pull/2

Задание 35: https://github.com/pochka2/VkuintRomanISP-232/pull/3

Ветка feature/git-basics: https://github.com/pochka2/VkuintRomanISP-232/pull/4

### Rebase result

Вывод `git log --oneline` после rebase в локальном репозитории:

```text
Rebasing (2/3)
Rebasing (3/3)
[detached HEAD c6a271f] docs: task 35 - rebase step 1
 Date: Mon Nov 9 15:26:29 2026 +0000
 1 file changed, 6 insertions(+)
Successfully rebased and updated refs/heads/feature/rebase-demo.
c6a271f docs: task 35 - rebase step 1
8fe1adb merge: feature/task-35
c3e3b67 merge: level-2
cb6189d docs: task 35 - describe branches
d2489b5 merge: level-1
```

### What I learned

Conventional Commits показывают назначение изменений. Rebase со squash объединяет три коммита в один.

### Rebase в GitHub

В ветке `feature/rebase-demo` были сделаны три коммита (`a3f907a`, `e5f54a0`, `8b3a7d8`). После объединения ветка указывает на `eb10d8a` — `docs: task 35 - squash rebase demo`. Эта история отдельно от локального примера выше.

### Проверка .gitignore

Есть `bin/`, `obj/`, `.vs/`, `.idea/`, `*.user`, `*.suo`.

### Примечание к истории

В истории основного репозитория .gitignore и .editorconfig первоначально добавлялись отдельными коммитами, а объединённый коммит `chore: add gitignore and editorconfig` появился позднее. Старую историю не переписывали.

## Task 46 — git stash

Выполнено в отдельном локальном учебном репозитории.

### Commands

```bash
git switch main
# Изменён demo.txt без коммита
git stash push -m "task 46: demo"
git stash list
git switch level-3
git switch main
git stash pop
git stash list
```

### Output (до stash pop)

```text
stash@{0}: On main: task 46: demo
```

### Output (после stash pop)

```text
git stash list: пустой список
demo.txt:
Строка 1
Незакоммиченное изменение
```

Изменение восстановлено, stash пуст.

## Task 47 — rebase -i

Выполнено в отдельном локальном учебном репозитории. Ветка `feature/squash-demo`.

### Commands

```bash
git switch -c feature/squash-demo
# Четыре коммита, изменяющие demo.txt
git rebase -i HEAD~4
# Второй, третий и четвёртый pick заменены на squash
git log --oneline
```

### Before (git log --oneline)

```text
a583d24 docs: task 47 - step 4
3702ab1 docs: task 47 - step 3
596a36b docs: task 47 - step 2
44340d0 docs: task 47 - step 1
80c013a chore: prepare git practice
```

### After (git log --oneline)

```text
bff8014 docs: task 47 - step 1
80c013a chore: prepare git practice
```

Четыре коммита объединены в один. В GitHub есть отдельная ветка `feature/squash-demo` с итоговым коммитом `dfd5f72`.

## Task 48 — git tags

Аннотированный тег создан и проверен только в отдельном локальном учебном репозитории.

### Commands

```bash
git tag -a v1.0.0 -m "Release v1.0.0"
git tag
git show v1.0.0
```

### Output (локальный пример)

```text
v1.0.0
tag v1.0.0
Tagger: Practicum Student <student@localhost>

Release v1.0.0
commit fa1604c4d25069f236bd40451be3d797cf2e1057
```

**В основном GitHub-репозитории тег v1.0.0 пока отсутствует.** Для завершения задания в нём нужно выполнить:

```bash
git switch main
git pull
git tag -a v1.0.0 -m "Release v1.0.0"
git push origin v1.0.0
git tag
git show v1.0.0
```

После публикации сюда нужно сохранить вывод `git tag` и `git show v1.0.0` из основного репозитория.

## Task 49 — git reflog

Выполнено в отдельном локальном учебном репозитории.

### Commands

```bash
git add demo.txt
git commit -m "feat: task 49 - restore a commit"
git reset --hard HEAD~1
git reflog
git reset --hard 09ab43e637f946392187201d5e85d94110c1c787
git reflog
git log --oneline
```

### Output (git reflog после удаления)

```text
e17d57e HEAD@{0}: reset: moving to HEAD~1
09ab43e HEAD@{1}: commit: feat: task 49 - restore a commit
e17d57e HEAD@{2}: commit (initial): chore: task 49 - initial
```

### Output (git reflog после восстановления)

```text
09ab43e HEAD@{0}: reset: moving to 09ab43e637f946392187201d5e85d94110c1c787
e17d57e HEAD@{1}: reset: moving to HEAD~1
09ab43e HEAD@{2}: commit: feat: task 49 - restore a commit
```

### Output (git log --oneline)

```text
09ab43e feat: task 49 - restore a commit
e17d57e chore: task 49 - initial
```

Коммит `09ab43e` успешно восстановлен.

## Task 50 — git bisect

Выполнено в отдельном локальном учебном Git-репозитории: 13 коммитов (начальный и 12 шагов).
На шаге 6 выражение `return number + 1;` заменено на `return number - 1;`.

### Commands

```bash
git bisect start
git bisect bad 1cff951
git bisect good 5897a8a
# На каждом выбранном коммите проверена функция:
git bisect bad
git bisect good
git bisect good
git bisect log
git bisect reset
git log --oneline
```

### Output (git bisect)

```text
Bisecting: 5 revisions left to test after this (roughly 3 steps)
[e9de375c340a9b324a89653d4935e22c5b2d1637] feat: task 50 - step 6
Check 1: e9de375 BAD
Bisecting: 2 revisions left to test after this (roughly 2 steps)
[60b52cdd24c3fab753592b29f9d57a4a0beca758] feat: task 50 - step 3
Check 2: 60b52cd GOOD
Bisecting: 0 revisions left to test after this (roughly 1 step)
[389a44a4f7807d369cb8c8d40a95913477d75227] feat: task 50 - step 5
Check 3: 389a44a GOOD
e9de375c340a9b324a89653d4935e22c5b2d1637 is the first bad commit
```

### Output (git bisect log)

```text
git bisect start
git bisect bad 1cff9518c200dce2b72f5d81f1a5f737f71047f4
git bisect good 5897a8a9c63b35cc6702adbf1a13a21598580bb4
git bisect bad e9de375c340a9b324a89653d4935e22c5b2d1637
git bisect good 60b52cdd24c3fab753592b29f9d57a4a0beca758
git bisect good 389a44a4f7807d369cb8c8d40a95913477d75227
# first bad commit: e9de375c340a9b324a89653d4935e22c5b2d1637
```

### Output (git bisect reset и git log --oneline)

```text
Switched to branch 'main'
1cff951 feat: task 50 - step 12
8c3cf8f feat: task 50 - step 11
abe23bd feat: task 50 - step 10
7cff13d feat: task 50 - step 9
dd6256f feat: task 50 - step 8
c36ddbe feat: task 50 - step 7
e9de375 feat: task 50 - step 6
389a44a feat: task 50 - step 5
```

Первый ошибочный коммит — `e9de375`. Исходная ветка восстановлена.

