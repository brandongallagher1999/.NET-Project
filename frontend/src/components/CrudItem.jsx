import { Fragment } from "react"; 


const CrudItem = (props) =>
{
    return (
        <Fragment>
            <tr>
                <td>
                    { props.id }
                </td>
                <td>
                    { props.name }
                </td>
                <td>
                    { props.description }
                </td>
                <td>
                    { props.date }
                </td>
            </tr>
        </Fragment>
    );
}

export default CrudItem;