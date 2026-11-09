# Git notes

## Task 15 — Basic git

Дальше приведена настоящая локальная учебная история Git. Её SHA не совпадают с коммитами GitHub.

### Commands

```bash
git init -b main
git switch -c level-1
git switch -c feature/git-basics
git add README.md
git commit -m "feat: task 15 - edit feature"
git switch level-1
git add README.md
git commit -m "feat: task 15 - edit main line"
git merge --no-ff feature/git-basics
# README.md исправлен вручную, маркеры конфликта удалены
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
*   bcf2069 feat: task 15 - resolve merge conflict
|\  
| * 6de9057 feat: task 15 - edit feature
* | 53f408e feat: task 15 - edit main line
|/  
* 0792d3a feat: task 14 - solution
* d6c9366 feat: task 13 - solution
* 8879e0e feat: task 12 - solution
* c4ab08d feat: task 11 - solution
* d4e1ba4 feat: task 10 - solution
* 94609fc feat: task 09 - solution
* efe7f6c feat: task 08 - solution
* a46f8a1 feat: task 07 - solution
* 62eb683 feat: task 06 - solution
* ab3fcf7 feat: task 05 - solution
* 0d60885 feat: task 04 - solution
* d71b5e8 feat: task 03 - solution
* afba782 feat: task 02 - solution
* 353203c feat: task 01 - solution
* 54ddbfd chore: create console project
```

### What I learned

Когда две ветки меняют одну строку, Git показывает конфликт. После исправления README.md можно сохранить merge-коммит.

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

Отдельный PR для задания 35 оформляется в GitHub.

### Rebase result

Вывод команды из локального репозитория (на GitHub хеши отличаются):

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

Шаг 1 для примера rebase.

Шаг 2 для примера rebase.

Шаг 3 для примера rebase.
