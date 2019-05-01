import React, {Component} from 'react';
import { Link } from "react-router-dom";
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

const styles = theme => ({
  table: {
    minWidth: 700,
  },
});

const TABLE_COLUMNS = [
    {
      label: '№ task',
      sort: 'default',
    },{
      label: 'Status',
      sort: 'default',
    },{
      label: 'Priority',
      sort: 'default',
    },{
      label: 'Description',
      sort: 'default',
    }
  ];

const TaskTableHeader = (props) => {
    return(
      <TableHead>
        <TableRow>
          {TABLE_COLUMNS.map((element, index) =>
            <TableCell key={index}>{element.label}</TableCell>
          )}
        </TableRow>
      </TableHead>
    )
  }

  const TaskTableBody = ({data}) => {
    return(
      <TableBody>
        {data.map((element, index) =>
              <TableRow key={index} hover>
                {element.map((item, i) =>
                  <TableCell key={i}>{item}</TableCell>
                )}
              </TableRow>
        )}
      </TableBody>
    )
  }


 class TasksTable extends Component {
    //static propTypes = {
        // data: React.PropTypes.array,
    //};
    
      constructor(props) {
        super(props);
    
        this.state = {
          data: [],
          column: TABLE_COLUMNS,
          selected: []
        }
      }
    
      componentWillMount() {
        const { data } = this.props;
        this.setState({ data })
      }
    
      componentWillReceiveProps(nextProps) {
        const { data } = nextProps;
        this.setState({ data })
      }

      ////////////////////
      // handleClick = (event, id) => {
      //   const { selected } = this.state;
      //   const selectedIndex = selected.indexOf(id);
      //   let newSelected = [];
    
      //   if (selectedIndex === -1) {
      //     newSelected = newSelected.concat(selected, id);
      //   } else if (selectedIndex === 0) {
      //     newSelected = newSelected.concat(selected.slice(1));
      //   } else if (selectedIndex === selected.length - 1) {
      //     newSelected = newSelected.concat(selected.slice(0, -1));
      //   } else if (selectedIndex > 0) {
      //     newSelected = newSelected.concat(
      //       selected.slice(0, selectedIndex),
      //       selected.slice(selectedIndex + 1),
      //     );
      //   }
    
      //   this.setState({ selected: newSelected });
      // };

      //isSelected = id => this.state.selected.indexOf(id) !== -1;
  
    render() {
      const { classes } = this.props;
      //const {data, selected} = this.state;
      return (
        <div>
          <Link to ="/task">TASK page</Link>
          <Table className={classes.table}>
            <TaskTableHeader columns={this.state.columns} />
            <TaskTableBody data={this.state.data} />
          </Table>
        </div>
      );
    }
  }

  TasksTable.propTypes = {
    classes: PropTypes.object.isRequired,
  };

  export default withStyles(styles)(TasksTable);