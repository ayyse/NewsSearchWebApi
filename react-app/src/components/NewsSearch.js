import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/news";
import { Table, Container, Row, Col } from 'react-bootstrap';

const NewsSearch = (props) => {
    // const  [x, setX] = useState(0)
    // setX(5)
    useEffect(() => {
        props.fetchAllNews()
    }, [])

    return(
        <Container>
            <Row>
                <Col sm={4}></Col>
                <Col sm={8}>
                    <Table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Word</th>
                                <th>Title</th>
                            </tr>
                        </thead>
                        <tbody>
                            {props.newsList.map((record, index) => {
                                return (
                                    <tr key = {index}>
                                        <td>{ record.id }</td>
                                        <td>{ record.word }</td>
                                        <td>{ record.title }</td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </Table>
                </Col>
            </Row>
        </Container>
    )
}

const mapStateToProps = state => ({
    newsList: state.news.list
})

const mapActionToProps = {
    fetchAllNews: actions.fetchAll
}

export default connect(mapStateToProps, mapActionToProps) (NewsSearch);