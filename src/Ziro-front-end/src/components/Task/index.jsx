import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import './task.css'
import '../Tasks/tasks.css'


const data = [ {
    'id': 'C-11',
    'status_id': 's0',
    'status_text': 'назначен',
    'type': 'нововведение',
    'priority': 'низкий',
    'name': 'fix color submit button',
    'author': 'qa',
    'description': 'Необходимо изменить цвет кнопки на красный',
    'comments':
        {
            'id': '001',
            'author': 'egor vikharev',
            'comment_text': 'hi everyone!'
        }
    }
]

class Task extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: data
        }
    }
    render() {
        return (
            <div className="container">
                <div className="task__wrap">
                    {data.map((elem,index)=>
                    <Paper className="task__block" key={index}>
                    <Typography className="task__name" component="h1" variant="h5"><span className="task__id">{elem.id}</span>{elem.name}</Typography>
                        <div className="task__status-block">
                            <div className={`${elem.status_id} task__status`}>{elem.status_text}</div>
                            <p className="task__status-text">
                            <span className="task__creator">{elem.author}</span>открыл эту задачу 
                            <span className="task__creation-date">30 04 2019</span>- <span className="task__comments-number">1</span> комментариев</p>
                        </div>
                        <div className="task__description-block">
                            <p className="task__type">Тип: <span>{elem.type}</span></p>
                            <p className="task__priority">Приоритет: <span>{elem.priority}</span></p>
                            <p className="task__description">Описание: <span>{elem.description}</span></p>
                            <img className="task__img" src="https://user-images.githubusercontent.com/2376915/31859948-e42fd92e-b71b-11e7-9383-3459f8aa3af5.png"/>
                        </div>                
                    </Paper>
                    )}
                </div>
                <div className="task-actions__block">
                    <div className="task-action">
                        <a className="task-action__author" href="#to-user-profile">
                            <img className="task-action__author-img" src="https://avatars1.githubusercontent.com/u/24210610?s=60&v=4" alt=""/>
                            <span className="task-action__author-name">Inna-ID</span>
                        </a>
                        <span className="task-action__name">открыла задачу</span>
                        <span className="task-action__date">30 04 2019</span>
                    </div>
                    <div className="task-action">
                        <a className="task-action__author" href="#to-user-profile">
                            <img className="task-action__author-img" src="https://avatars1.githubusercontent.com/u/24210610?s=60&v=4" alt=""/>
                            <span className="task-action__author-name">Inna-ID</span>
                        </a>
                        <span className="task-action__name">закрыла задачу</span>
                        <span className="task-action__date">31 04 2019</span>
                    </div>
                </div>
            </div>
        )
    }
}

export default Task;
