namespace LearningMaterials.Git
{
	public class GitCommands
	{
		public string GitInit => "git init: Initializes a new Git repository in the current directory.";
		public string GitClone => "git clone: Clones an existing repository into a new directory.";
		public string GitAdd => "git add: Adds changes from the working directory to the staging area.";
		public string GitCommit => "git commit: Records changes in the repository with a message describing the changes.";
		public string GitPush => "git push: Sends committed changes to the remote repository.";
		public string GitPull => "git pull: Fetches and integrates changes from a remote repository to the current branch.";
		public string GitBranch => "git branch: Lists, creates, or deletes branches.";
		public string GitCheckout => "git checkout: Switches between branches or restores files in the working directory.";
		public string GitMerge => "git merge: Merges changes from one branch into the current branch.";
		public string GitRebase => "git rebase: Reapplies commits on top of another base tip.";
		public string GitStatus => "git status: Shows the working directory status and staged changes.";
		public string GitLog => "git log: Shows the commit history of the repository.";
		public string GitStash => "git stash: Temporarily saves changes that are not ready to be committed.";
		public string GitReset => "git reset: Resets the current branch to a previous state.";
		public string GitRevert => "git revert: Reverses a commit by creating a new commit that undoes changes.";
		public string GitFetch => "git fetch: Downloads objects and refs from another repository without integrating.";
		public string GitDiff => "git diff: Shows changes between commits, branches, or the working directory.";
		public string GitRemote => "git remote: Manages set of tracked repositories.";
		public string GitTag => "git tag: Creates, lists, or deletes tags in the repository.";
		public string GitCherryPick => "git cherry-pick: Applies changes from specific commits to the current branch.";
		public string GitMv => "git mv: Moves or renames a file in the working directory.";
		public string GitRm => "git rm: Removes files from the working directory and from the index.";
		public string GitBlame => "git blame: Shows who made changes to a file, line by line.";
		public string GitReflog => "git reflog: Shows the reference logs for branches and commits.";
		public string GitSubmodule => "git submodule: Manages submodules which are external repositories inside a project.";
		public string GitClean => "git clean: Removes untracked files from the working directory.";
	}
}
