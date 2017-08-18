const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        Task.find().then(tasks => {
            res.render('task/index', {'tasks': tasks});
		})

    },
	createGet: (req, res) => {
        res.render('task/create');
	},
	createPost: (req, res) => {
        let taskArgs = req.body;
        let errorMsg = '';
        if (!taskArgs.title) {
        	errorMsg = 'Invalid title!';
		} else if (!taskArgs.comments) {
        	errorMsg = 'Invalid comments!';
		}

		if (errorMsg) {
        	res.render('task/create', {error: errorMsg});
        	return;
		}

		Task.create(taskArgs).then(task => {
			res.redirect('/');
		});
	},
	deleteGet: (req, res) => {
    	let id = req.params.id;
    	Task.findById(id).then(task => {
    		res.render('task/delete', task);
		});

	},
	deletePost: (req, res) => {
		let id = req.params.id;
		Task.findByIdAndRemove(id).then(task => {
			res.redirect('/');
		})
	}
};